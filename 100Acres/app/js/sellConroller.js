function sellCtrl($scope, Property) {
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

    //Initialize properties
    $scope.GeneralInformation = new Object();
    $scope.PropertyFeature = {};

    //Default DD List values
    InitializeGenInfo();

    $scope.GeneralInformation.Save = function () {
        Property.save($scope.GeneralInformation).success(function (data, status) {
            
        }).error(function (status) {
            
        });
    }

    $scope.GeneralInformation.Reset = function () {
        InitializeGenInfo();
        Reset();
    }

    $scope.PropertyFeature.Save = function () {
        Property.save($scope.PropertyFeature).success(function (data, status) {

        }).error(function (status) {

        });
    }

    function InitializeGenInfo() {
        //Set Default values
        $scope.GeneralInformation.TransactionType = 'Sale';
        $scope.GeneralInformation.PropertyCategory = 'Select a Category';
        $scope.GeneralInformation.PropertyType = 'Select Type';
        $scope.GeneralInformation.PropertyStatus = 'Any';
        $scope.GeneralInformation.LandAreaUnit = 'Select';
        $scope.GeneralInformation.PerUnitUnit = 'Select';
        $scope.GeneralInformation.BuildUpAreaUnit = "Select";
        $scope.GeneralInformation.Region = 'Select Region';
        $scope.GeneralInformation.District = 'Select District/Area';
    }

    //set values to empty
    function Reset() {
        $scope.GeneralInformation.Title = '';
        $scope.GeneralInformation.PropertyAge = '';
        $scope.GeneralInformation.NoOfBedrooms = '';
        $scope.GeneralInformation.NoOfBathrooms = '';
        $scope.GeneralInformation.BuildUpArea = '';
        $scope.GeneralInformation.PlotArea = '';
        $scope.GeneralInformation.LandArea = '';
        $scope.GeneralInformation.PropertyPrice = '';
        $scope.GeneralInformation.PriceNegotiable = false;
        $scope.GeneralInformation.Description = '';
        $scope.GeneralInformation.PropertyDetails = '';
        $scope.GeneralInformation.City = '';
        $scope.GeneralInformation.Location = '';
        $scope.GeneralInformation.ContactName = '';
        $scope.GeneralInformation.ContactAddress = '';
        $scope.GeneralInformation.ContactPhone = '';
        $scope.GeneralInformation.ContactMobile = '';
    }

    $scope.DropDown = {};
    $scope.DropDown.Category = ['Select a Category', 'Residential', 'Commercial', 'SEZ', 'Land', 'Projects'];
    $scope.DropDown.PropertyType = ['Select Type', 'Residential Land / Plot', 'Commercial / Industrial Land', 'Agricultural Land', 'Plantation / Estate', 'Commercial cum Residential'];
    $scope.DropDown.PropertyStatus = ['Any', 'New', 'Resale'];
    $scope.DropDown.Unit = ['Select', 'Sq.Feet', 'Sq.Meter', 'Cent', 'Acre'];
    $scope.DropDown.Region = ['Select Region', 'Kerala', 'Outside Kerala'];
    $scope.DropDown.District = ['Select District/Area', 'Alappuzha', 'Ernakulam', 'Idukki', 'Kannur', 'Kasargod', 'Kollam', 'Kottayam', 'Kozhikode', 'Malappuram', 'Palakkad', 'Pathanamthitta', 'Thiruvanthapuram', 'Wayanad'];
}