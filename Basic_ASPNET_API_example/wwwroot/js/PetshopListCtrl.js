'use strict';
angular.module('petshopApp')
.controller('PetshopListCtrl', ['$scope', '$location', 'PetshopListSvc', function ($scope, $location, PetshopListSvc) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.petshopList = null;
    $scope.editingInProgress = false;
    $scope.newPetshopItemName = "";
    $scope.newPetshopItemSpecies = "";
    $scope.newPetshopItemPedigree = "";
    $scope.newPetshopItemColour = "";
    $scope.newPetshopItemAge = 0;
    $scope.newPetshopItemPrice = 0;


    $scope.editInProgressPetshopitem = {
        name: "",
        species: "",
        pedigree: "",
        colour: "",
        age: 0,
        price: 0,
        isAdopted: true,
        id: 0
    };

    

    $scope.editSwitch = function (petshopitem) {
        petshopitem.edit = !petshopitem.edit;
        if (petshopitem.edit) {
            $scope.editInProgressPetshopitem.name = petshopitem.name;
            $scope.editInProgressPetshopitem.species = petshopitem.species;
            $scope.editInProgressPetshopitem.pedigree = petshopitem.pedigree;
            $scope.editInProgressPetshopitem.colour = petshopitem.colour;
            $scope.editInProgressPetshopitem.age = petshopitem.age;
            $scope.editInProgressPetshopitem.price = petshopitem.price;
            $scope.editInProgressPetshopitem.id = petshopitem.id;
            $scope.editInProgressPetshopitem.isAdopted = petshopitem.isAdopted;
            $scope.editingInProgress = true;
        } else {
            $scope.editingInProgress = false;
        }
    };

    $scope.populate = function () {
        petshopListSvc.getItems().success(function (results) {
            $scope.petshopList = results;
            $scope.loadingMessage = "";
        }).error(function (err) {
            $scope.error = err;
            $scope.loadingMessage = "";
        })
    };
    $scope.delete = function (id) {
        petshopListSvc.deleteItem(id).success(function (results) {
            $scope.loadingMessage = "";
            $scope.populate();
        }).error(function (err) {
            $scope.error = err;
            $scope.loadingMessage = "";
        })
    };
    $scope.update = function (petshopitem) {
        $scope.editInProgressPetshopitem.isAdopted = petshopitem.isAdopted;
        petshopListSvc.putItem($scope.editInProgressPetshopitem).success(function (results) {
            $scope.loadingMsg = "";
            $scope.populate();
            $scope.editSwitch(petshopitem);
        }).error(function (err) {
            $scope.error = err;
            $scope.loadingMessage = "";
        })
    };
    $scope.add = function () {
        if ($scope.editingInProgress) {
            $scope.editingInProgress = false;
        }
        petshopListSvc.postItem({
            'Name': $scope.newPetshopItemName,
            'Species': $scope.newPetshopItemSpecies,
            'Pedigree': $scope.newPetshopItemPedigree,
            'Colour': $scope.newPetshopItemColour,
            'Age': $scope.newPetshopItemAge,
            'Price': $scope.newPetshopItemPrice,
            'IsAdopted': false
        }).success(function (results) {
            $scope.loadingMsg = "";
            $scope.newPetshopItemName = "";
            $scope.newPetshopItemSpecies = "";
            $scope.newPetshopItemPedigree = "";
            $scope.newPetshopItemColour = "";
            $scope.newPetshopItemAge = 0;
            $scope.newPetshopItemPrice = 0;
            $scope.populate();
        }).error(function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        })
    };

}]);
