﻿var NgCooking = angular.module('NgCooking', ['NgCooking.userModule', 'NgCooking.recipeModule', 'NgCooking.recipeCategoryModule', 'NgCooking.ingredientModule', 'NgCooking.ingredientCategoryModule', 'ngCookies']);


NgCooking.directive('starRating', starRating);

NgCooking.service('authService', ['$cookies','$rootScope', function ($cookies, $rootScope) {
    var user = $cookies.getObject('User') || null;


    return {
        login: function (User) {
            if ($cookies.getObject('User') == null) {
                $cookies.putObject('User', User, { path: '/', domain: 'localhost' });
                $rootScope.$emit('notifying-service-event');
            }
        },
        logout: function () {
            $cookies.remove('User', { path: '/', domain: 'localhost' });
            $rootScope.$emit('notifying-service-event');
        },
        currentUser: function () {
            return $cookies.getObject('User');
        },
        subscribe: function(scope, callback) {
        var handler = $rootScope.$on('notifying-service-event', callback);
                scope.$on('$destroy', handler);
        },

    }
}]);

function starRating() {
    return {
        restrict: 'EA',
        template:
          '<ul class="star-rating" ng-class="{readonly: readonly}">' +
          '  <li ng-repeat="star in stars" class="star" ng-class="{filled: star.filled}" ng-click="toggle($index)">' +
          '    <i class="fa fa-star"></i>' + // or &#9733
          '  </li>' +
          '</ul>',
        scope: {
            rateValue: '=ngModel',
            ratingValue: '@',
            max: '=?', // optional (default is 5)
            onRatingSelect: '&?',
            readonly: '=?'

        },
        link: function (scope, element, attributes) {
            if (scope.max == undefined) {
                scope.max = 5;
            }
            function updateStars() {
                scope.stars = [];
                for (var i = 0; i < scope.max; i++) {
                    scope.stars.push({
                        filled: i < scope.ratingValue
                    });
                }
            };
            scope.toggle = function (index) {
                if (scope.readonly == undefined || scope.readonly === false && index != 0) {
                    scope.ratingValue = index + 1;
                    scope.rateValue = index + 1;
                }

            };
            scope.$watch('ratingValue', function (oldValue, newValue) {
                updateStars();
            });
        }
    };
}