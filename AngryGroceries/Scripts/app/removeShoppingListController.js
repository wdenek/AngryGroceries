angular.module("AngryGroceries").controller("RemoveShoppingListController", function ($scope, dialog, shoppingList) {
    $scope.shoppingList = shoppingList;

    $scope.close = function(result) {
        dialog.close(result);
    };
});