
var app = angular.module('100acres', ['ngResource', 'ui.bootstrap.pagination']);

app.factory('Property', function ($q, $http) {
    //return $resource('app/listings/listings.json', {}, { newListings: { method: 'GET', cache: true, isArray: true} });
    var listings = [];
    return {
        newListings: function () {
            var deferred = $q.defer();
            $http.get('app/listings/listings.json').success(function (data) {
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

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/properties', {templateUrl:'app/partials/property_listings.htm', controller:propertyListCtrl}).
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

