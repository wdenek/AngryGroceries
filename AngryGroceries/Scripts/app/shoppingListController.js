angular.module('AngryGroceries').controller('ShoppingListController', ["$scope", "$dialog","shoppingListService", function ($scope, $dialog,shoppingListService) {
    // Public properties
    //----------------------------------------
    $scope.newItemText = "";

    $scope.shoppingListItems = [];

    $scope.shoppingLists = [];

    // Private functions
    //----------------------------------------
    function updateShoppingLists(selectedListId) {
        shoppingListService.getShoppingLists().then(function (data) {
            // Clear the shopping lists by setting the length to zero.
            $scope.shoppingLists.length = 0;
            
            // Load the new shopping lists into the UI.
            for (var i = 0; i < data.length; i++) {
                $scope.shoppingLists.push(data[i]);
            }
            
            if (selectedListId) {
                for (var j = 0; j < $scope.shoppingLists.length; j++) {
                    if ($scope.shoppingLists[j].Id == selectedListId) {
                        $scope.selectShoppingList($scope.shoppingLists[j]);
                        break;
                    }
                }
            } else {
                // Select the last shopping list in the dropdown
                // when no list was previously selected.
                $scope.selectShoppingList($scope.shoppingLists[$scope.shoppingLists.length - 1]);
            }
        });
    }

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
            shoppingListService.createShoppingList(result).then(function() {
                updateShoppingLists();
            });
        });
    };

    $scope.editShoppingList = function () {
        if ($scope.shoppingLists.length == 0) return;

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

            shoppingListService.updateShoppingList(result).then(function() {
                updateShoppingLists(result.Id);
            });
        });
    };
    
    $scope.removeShoppingList = function () {
        if ($scope.shoppingLists.length == 0) return;

        var dialog = $dialog.dialog({
            // Use a custom resolve to pass in the shopping list that is currently selected.
            // A copy is used to make the dialog somewhat transactional here.
            resolve: {
                shoppingList: function () { return angular.copy($scope.selectedShoppingList); }
            },
            backdrop: true,
            keyboard: true
        });

        dialog.open("/Scripts/app/templates/RemoveShoppingList.html", "RemoveShoppingListController").then(function (result) {
            if (!result) return;

            shoppingListService.deleteShoppingList($scope.selectedShoppingList.Id).then(function() {
                updateShoppingLists();
            });
        });
    };

    $scope.selectShoppingList = function (shoppingList) {
        // Skip processing the rest of the method when no shopping list is selected.
        if (!shoppingList) {
            $scope.shoppingListItems = [];
            $scope.selectedShoppingList = null;
            return;
        }

        // For now, just use a dummy list of items.
        $scope.shoppingListItems = [{
            id: 1,
            completed: false,
            text: "Sample item 1"
        }, {
            id: 2,
            completed: true,
            text: "Sample item 2"
        }];

        // Store the selected list in the scope of the controller.
        // The rest of the UI uses this to refer to the current shopping list.
        $scope.selectedShoppingList = shoppingList;
    };

    $scope.editItem = function(shoppingListItem) {
        var dialog = $dialog.dialog({
            // Use a custom resolve to pass in the shopping list that is currently selected.
            // A copy is used to make the dialog somewhat transactional here.
            resolve: {
                shoppingListItem: function () { return angular.copy(shoppingListItem); }
            },
            backdrop: true,
            keyboard: true
        });

        dialog.open("/Scripts/app/templates/EditItem.html", "EditItemController").then(function (result) {
            if (!result) return;

            shoppingListItem.text = result.text;
        });
    };

    $scope.removeItem = function(shoppingListItem) {
        var dialog = $dialog.dialog({
            // Use a custom resolve to pass in the shopping list that is currently selected.
            // A copy is used to make the dialog somewhat transactional here.
            resolve: {
                shoppingListItem: function () { return angular.copy(shoppingListItem); }
            },
            backdrop: true,
            keyboard: true
        });

        dialog.open("/Scripts/app/templates/RemoveItem.html", "RemoveItemController").then(function (result) {
            if (!result) return;
            
            // Use splice to remove the shopping list item from the list.
            // This manipulates the array in-place.
            $scope.shoppingListItems.splice($scope.shoppingListItems.indexOf(shoppingListItem), 1);
        });
    };

    $scope.filterIncompleteItems = function (item) {
        return !item.completed;
    };

    $scope.filterCompletedItems = function (item) {
        return item.completed;
    };

    $scope.hasItems = function () {
        return $scope.shoppingListItems.length;
    };

    $scope.hasShoppingLists = function() {
        return $scope.shoppingLists.length;
    };
    
    $scope.isEverythingCompleted = function () {
        for (var index = 0; index < $scope.shoppingListItems.length; index++) {
            if (!$scope.shoppingListItems[index].completed) return false;
        }

        return true;
    };

    $scope.isNothingCompleted = function () {
        for (var index = 0; index < $scope.shoppingListItems.length; index++) {
            if ($scope.shoppingListItems[index].completed) return false;
        }

        return true;
    };

    $scope.hasItems = function () {
        return $scope.shoppingListItems.length;
    };

    // Initialization
    //----------------------------------------
    updateShoppingLists();
}]);