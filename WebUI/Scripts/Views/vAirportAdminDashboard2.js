function vAirportAdminDashboard2() {

	this.chartId = 'myChart2';
	this.service = 'airline';
	this.ctrlActions = new ControlActions();

	this.GetDataToChart = function (initializeChartFunction) {

		this.ctrlActions.GetToApi(this.service + '?type=activeInactiveAirlines', initializeChartFunction);

	};


}