angular.module("AngryGroceries").controller("EditShoppingListController", function ($scope, dialog, shoppingList) {

    $scope.errorMessage = "";
    $scope.shoppingList = shoppingList;

    $scope.close = function(result) {
        if (result && !$scope.shoppingList.Name) {
            $scope.errorMessage = "Please provide a name for the shopping list";
            return;
        }

        dialog.close(result && $scope.shoppingList);
    };
});