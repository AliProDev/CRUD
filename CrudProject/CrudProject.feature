Feature: CrudProject

@CrudProject

Scenario: launch application and test CRUD operation
	Given launch application
	And click add new record button and create new information
	| ProductName | UnitPrice | UnitsInStock | Discontinued | Save |
	| product1    | 26        | 15           | true         | true |
	When find new record as grid and click edit button and edit information
	| ProductName | UnitPrice | UnitsInStock | NewProductName | NewUnitPrice | NewUnitsInStock | NewDiscontinued | Update |
	| product1    | 26        | 15           | Newproduct1    | 36           | 25              | false           | true   |
	Then find edit record as grid and delete it
	| ProductName | UnitPrice | UnitsInStock | Delete |
	| Newproduct1 | 36        | 25           | true   |