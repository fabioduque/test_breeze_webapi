var app = angular.module('app', [
    'breeze.angular' // the breeze service module
    ]);

// Ensure that breeze is minimally configured by loading it when the app runs
// app.run(['breeze', function (breeze) { 
// }]);



app.controller("HomeController", ["breeze", "$scope", function(breeze, $scope) {
  
  $scope.results = [];

  var manager = new breeze.EntityManager('http://localhost:9977/breeze/Todos/');
  
  var query = new breeze.EntityQuery()
      .from("./Todos");

  
  manager.executeQuery(query).then(function(data){
    
    // Success callback
    $scope.results = data.results;
    
  }, function (e) {
    
    // Fail callback
    console.error(e);  
  });

  $scope.editItem = function (todoItem) {
    todoItem.editing = true;
    todoItem.saved = false;
  };

  $scope.doneEditing = function (todoItem) {
    todoItem.editing = false;
  };
 

  $scope.saveNew = function(newTodo) {
    // angular.extend(newTodo, {"CreatedAt": new Date()});
    var item = manager.createEntity("TodoItem", newTodo);
    item.createdNow = true;
    console.log(item);
    manager.saveChanges().then(function (data) {
      $scope.results.push(item);
    });
    
  };

  $scope.update = function () {
    console.log("update");
    if (manager.hasChanges() )
      manager.saveChanges().then( function (data) {
        angular.forEach(data.entities, function (todo) {
          $scope.doneEditing(todo);
          todo.saved = true;
        });
        console.log(data);
      } , function (e) {
        console.error(e);
      });
  };

  $scope.markCompleted = function () {

  };

}]);

