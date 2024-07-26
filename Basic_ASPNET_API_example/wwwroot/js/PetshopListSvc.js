'use strict';
angular.module('petshopApp')
.factory('petshopListSvc', ['$http', function ($http) {

    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With']; 

    return {
        getItems : function(){
            return $http.get(apiEndpoint + '/list');
        },
        getItem : function(id){
            return $http.get(apiEndpoint + '/getId/' + id);
        },
        postItem : function(item){
            return $http.post(apiEndpoint + '/api/petshopitems', item);
        },
        putItem : function(item){
            return $http.put(apiEndpoint + '/api/Petshopitems/' + item.id, item);
        },
        deleteItem : function(id){
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/Petshopitems/' + id
            });
        }
    };
}]);