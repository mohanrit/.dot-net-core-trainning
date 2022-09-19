CREATE TABLE employees (
    employee_id int NOT NULL,
    name varchar(50) NOT NULL,
    status varchar(50) NOT NULL,
    manager varchar(30),
    wfm_manager varchar(30),
    email text,
    lockstatus varchar(30),
    experience decimal(5,0),
    profile_id int,
    primary key (employee_id)
);

insert into employees values ( 445,'Sriragav', 'approved','vishruth','Sabari','sriragavd@softura.com','Not Locked',2,100)
insert into employees values ( 462,'Ragu', 'rejected','Anand','Mohammed','ragus@softura.com','Locked',3,101)
insert into employees values ( 463,'Selva', 'approved','Kumaran','Govind','selvar@softura.com','Not Locked',4,102)
insert into employees values ( 468,'Senthil', 'approved','Kiran','Kalidass','senthilk@softura.com','Not Locked',4,102)


CREATE TABLE users (
    username varchar(30) NOT NULL primary key,
    password varchar(30) NOT NULL,
    name varchar(30) NOT NULL,
    role varchar(30) NOT NULL,
    email text
);

insert into users values ('Sairangan' , 'Sai@19', 'Sairangan','Software Engineer','Sairangan@gmail.com')
insert into users values ('Vignesh' , 'Vignesh@2020', 'Vignesh','Junior Software Engineer ','Vignesh@gmail.com')
insert into users values ('Priya' , 'Priya@it465', 'Priyanka','Test Engineer','Priyanka@gmail.com')
insert into users values ('Deena' , 'Deenit@222', 'Deena','Software Engineer','Deenait@gmail.com')

CREATE TABLE skills (
	skillid decimal(5,0) NOT NULL,
    name varchar(30) NOT NULL,
    primary key (skillid)
);

insert into skills values (1, 'javascript,sql server,C#')
insert into skills values (2, 'Angular,react js,node js')
insert into skills values (3, 'C#,javascript,jquery')
insert into skills values (4, 'C#,react js,jquery,javascript')

CREATE TABLE skillmap (
	employee_id int ,
	skillid decimal(5,0) ,
	FOREIGN KEY (employee_id) REFERENCES employees (employee_id),
    FOREIGN KEY (skillid) REFERENCES skills (skillid)
);

insert into skillmap values (445, 1)
insert into skillmap values (462, 2)
insert into skillmap values (463, 3)
insert into skillmap values (468, 4)

CREATE TABLE softlock (
	employee_id int ,
	manager varchar(30),
    reqdate date,
    status varchar(30),
    lastupdated date,
    lockid int not null identity(1,1),
    requestmessage text,
    wfmremark text,
    managerstatus varchar(30),
    mgrstatuscomment text,
    mgrlastupdate date,
    primary key (lockid),
	FOREIGN KEY (employee_id) REFERENCES employees (employee_id)
);

insert into softlock(employee_id,manager,reqdate,status,lastupdated,requestmessage,wfmremark,managerstatus,mgrstatuscomment,mgrlastupdate)
values (445, 'vishruth','2022-09-05','Requested','2022-08-16','Employee selected','','','',null)

