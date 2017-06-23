// tripController.js
(function () {
  "use-strict";

  //Getting the existing module
  angular.module("app-trips")
    .controller("tripsController", tripsController);

  function tripsController($http) {
    var vm = this;
    //vm.name = "khanhdd";
    vm.trips = [];

    var errorMessage = "";

    vm.newTrip = {};
    vm.isBusy = false;

    $http.get("/api/trips")
      .then(function (response) {
        angular.copy(response.data, vm.trips);
      },
      function (error) {
        vm.errorMessage = "Failed to load data: " + error;
      }).finally(function () {
        //vm.isBusy = false;
      })

    vm.addTrip = function () {
      vm.isBusy = true;
      $http.post("/api/trips", vm.newTrip)
        .then(function (response) {
          vm.trips.push(response.data);
          vm.newTrip = {};
        },
        function (error) {
          vm.errorMessage = "Failed to save data: " + error;
        })
        .finally(function () { vm.isBusy = false; });
    }


  }
})();