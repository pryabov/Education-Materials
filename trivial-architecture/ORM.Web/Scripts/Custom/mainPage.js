var MainPageViewModel = function () {
	var self = this;

	this.items = ko.observableArray([]);

	this.gridViewModel = new ko.simpleGrid.viewModel({
		data: self.items,
		columns: [
			{ headerText: "Brand", rowText: "brand" },
			{ headerText: "Color", rowText: "color" },
			{ headerText: "Number", rowText: "number" },
			{ headerText: "Odometer", rowText: "odometer" }
		],
		pageSize: 5
	});

	this.addRandomCar = function () {
		$.post("api/cars/addRandomCar").done(function() {
			self.updateGrid(true);
		});
	}

	this.updateGrid = function (isMoveToLastPage) {
		$.get('api/cars', function (data) {
			self.items(ko.toJS(data));
			if (isMoveToLastPage) {
				self.gridViewModel.currentPageIndex(self.gridViewModel.maxPageIndex());
			}
		});
	}

	$(function() {
		self.updateGrid();
	});
}

ko.applyBindings(new MainPageViewModel());