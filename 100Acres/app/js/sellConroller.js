function sellCtrl($scope) {
    $scope.tabs = {
        displayGeneralInformation: true,
        displayPropertyFeatures: false,
        displayUploadPhoto: false
    };

    $scope.tabs.click = function (tab) {
        hideTabs();
        $scope.tabs[tab] = true;
    }

    function hideTabs() {
        $scope.tabs.displayGeneralInformation = false;
        $scope.tabs.displayPropertyFeatures = false;
        $scope.tabs.displayUploadPhoto = false;
    }
}