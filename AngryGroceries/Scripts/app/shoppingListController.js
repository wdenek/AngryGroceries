angular.module('AngryGroceries')
       .controller('ShoppingListController', function ($scope, $dialog) {
           // Public properties
           //----------------------------------------
           $scope.newItemText = "";

           $scope.shoppingListItems = [];

           $scope.shoppingLists = [{
               id: 1,
               name: "My first list"
           }, {
               id: 2,
               name: "My second list"
           }];

           // Public functions
           //----------------------------------------
           $scope.addItem = function () {
               // Make sure we're not adding any empty items to the list
               if (!$scope.newItemText) return;

               // Create a new task and add it to the list of items
               $scope.shoppingListItems.push({
                   text: $scope.newItemText,
                   completed: false,
                   id: $scope.shoppingListItems.length
               });

               // Clear the new item text
               $scope.newItemText = "";
           };

           $scope.createNewShoppingList = function () {

               // Open the dialog and when it's complete, use the callback to store the shopping list.
               var dlg = $dialog.dialog({
                   backdrop: true,
                   keyboard: true
               });

               dlg.open("/Scripts/app/templates/CreateShoppingList.html", "CreateShoppingListController").then(function (result) {
                   // Do not process empty shopping list results
                   if (!result) return;

                   // Add the new shopping list to the collection
                   $scope.shoppingLists.push({
                       id: $scope.shoppingLists.length,
                       name: result
                   });

                   // Select the newly created shopping list
                   $scope.selectShoppingList($scope.shoppingLists[$scope.shoppingLists.length - 1]);
               });
           };

           $scope.editShoppingList = function () {
               var dlg = $dialog.dialog({
                   // Use a custom resolve to pass in the shopping list that is currently selected.
                   // A copy is used to make the dialog somewhat transactional here.
                   resolve: {
                       shoppingList: function () { return angular.copy($scope.selectedShoppingList); }
                   },
                   backdrop: true,
                   keyboard: true
               });

               dlg.open("/Scripts/app/templates/EditShoppingList.html", "EditShoppingListController").then(function (result) {
                   if (!result) return;

                   // Copy over the changed attributes of the updated shopping list entity.
                   $scope.selectedShoppingList.name = result.name;
               });
           };

           $scope.selectShoppingList = function (shoppingList) {
               $scope.shoppingListItems = [{
                   id: 1,
                   completed: false,
                   text: "Sample item 1"
               }, {
                   id: 2,
                   completed: true,
                   text: "Sample item 2"
               }];

               $scope.selectedShoppingList = shoppingList;
           };

           $scope.filterIncompleteItems = function (item) {
               return !item.completed;
           };

           $scope.filterCompletedItems = function (item) {
               return item.completed;
           };

           $scope.hasItems = function() {
               return $scope.shoppingListItems.length;
           };

           $scope.isEverythingCompleted = function() {
               for (var index = 0; index < $scope.shoppingListItems.length; index++) {
                   if (!$scope.shoppingListItems[index].completed) return false;
               }

               return true;
           };

           $scope.isNothingCompleted = function() {
               for (var index = 0; index < $scope.shoppingListItems.length; index++) {
                   if ($scope.shoppingListItems[index].completed) return false;
               }

               return true;
           };

           $scope.hasItems = function() {
               return $scope.shoppingListItems.length;
           };
           
           // Initialization
           //----------------------------------------
           $scope.selectShoppingList($scope.shoppingLists[0]);
       });