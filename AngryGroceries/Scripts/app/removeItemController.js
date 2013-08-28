angular.module("AngryGroceries").controller("RemoveItemController", function ($scope, dialog, shoppingListItem) {
    $scope.shoppingListItem = shoppingListItem;

    $scope.close = function (result) {
        dialog.close(result);
    };
});