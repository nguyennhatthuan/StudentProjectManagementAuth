var app = angular.module("app", ['ui.bootstrap', 'ngRoute']);

//Routes
app.config(['$routeProvider', '$locationProvider', 

	function($routeProvider, $locationProvider) {

		$routeProvider
		.when ('/Dashboard', {
			templateUrl: '/Administrator/Dashboard'
		})

		.when ('/TestThanh', {
			template: '<h2 style="color: #FFFFFF">Test thanh</h2>'
		})

		.when ('/TestCong', {
			template: '<h2 style="color: #FFFFFF">Test tinh yeu</h2>'
		})

		.when ('/ProfessorManagement', {
			template: '<h2 style="color: #FFFFFF">Test tinh yeu</h2>'
		})

		.otherwise({ redirectTo: '/Dashboard' });

	}

]);
