
var app = angular.module('100acres', ['ngResource', 'ui.bootstrap.pagination', 'ui.bootstrap.carousel']);

app.factory('Property', function ($q, $http) {
    //return $resource('app/listings/listings.json', {}, { newListings: { method: 'GET', cache: true, isArray: true} });
    return {
        newListings: function () {
            var deferred = $q.defer();
            $http.get('http://localhost/100AcresAPI/api/property').success(function (data) {
                deferred.resolve(data);
            }).error(function (data, status) {
                deferred.reject();
            });

            return deferred.promise;
        }
    }
});

app.factory('propertyDetail', function ($q, $http) {
    return {
        loadDetail: function (id) {
            var deferred = $q.defer();
            var url = 'app/listings/' + id + '.json';
            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (data, status) {
                deferred.reject();
            });

            return deferred.promise;
        }
    }
});

app.factory('Page', function () {
    return {
        loadDataForCurrentPage: function (allListings, pageNo) {
            var startIndex = (this.PageSettings.itemsPerPage * (pageNo - 1));
            var endIndex = (startIndex) + this.PageSettings.itemsPerPage;
            return allListings.slice(startIndex, endIndex);
        },
        PageSettings: {
            itemsPerPage: 10,
            maxSize: 5,
            bigCurrentPage: 1
        }
    }
});

app.factory('Register', function ($q, $http) {
    return {
        newUser: function (user) {
            var deferred = $q.defer();
            $http.post('http://localhost/100AcresAPI/api/register', user).success(function (data, status) {
                deferred.resolve(data);
            }).error(function (data) {
                deferred.reject();
            });

            return deferred.promise;
        }
    }
});

app.factory('styleSheet', function () {
    return {
        loadCss: function (name) {
            
        }
    }
});

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
    when('/properties', {templateUrl:'app/partials/property_listings.htm', controller:propertyListCtrl}).
    when('/properties/:Id', { templateUrl: 'app/partials/property_detail.htm', controller: propertyDetailCtrl }).
    when('/register', { templateUrl: 'app/partials/register.htm', controller: registerUserCtrl }).
    when('/sell', {templateUrl:'app/partials/sellProperty.htm', controller: sellCtrl }).
    otherwise({redirectTo:'/properties'});
} ]);

//app.directive('pagination', function () {
//    return {
//        restrict: 'A',
//        link: function (scope, element, attrs) {
//            $('div.holder').jPages({containerID:'listingContainer', perPage: scope.$eval(attrs.pagination).pageSize});
//    }
//};
//});

