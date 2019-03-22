create table CountryMaster
(
	CountryId int primary key identity,
	CountryName varchar(30) not null unique,
	IsCountryEnabled bit not null
);

create table StateMaster
(
	StateId int primary key identity,
	StateName varchar(30) not null unique,
	RefCountryId int not null references CountryMaster(CountryId),
	IsStateEnabled bit not null
);

create table CityMaster
(
	CityId int primary key identity,
	CityName varchar(30) not null unique,
	RefStateId int not null references StateMaster(StateId),
	IsCityEnabled bit not null
)