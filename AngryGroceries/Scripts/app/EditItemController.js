angular.module("AngryGroceries").controller("EditItemController", function ($scope, dialog, shoppingListItem) {
    $scope.shoppingListItem = shoppingListItem;

    $scope.close = function (result) {
        $scope.errorMessage = "";

        if (!$scope.shoppingListItem.text && result) {
            $scope.errorMessage = "Please enter a description for the shopping list item.";
            return;
        }

        dialog.close(result && $scope.shoppingListItem);
    };
});