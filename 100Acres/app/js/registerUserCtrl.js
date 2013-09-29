
function registerUserCtrl($scope, Register) {
    $scope.RegisterUser = function () {
        Register.newUser($scope.User);
    }
}