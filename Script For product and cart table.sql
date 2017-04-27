
Make sure Dabase file is following Format

                     **** foldername/Filename.extension************
                    *****For ex. Images/1.jpg**********



create table products
(
id int primary key identity,
nm varchar(20),
disc varchar(20),
price int,
img varchar(30)
)

select * from products


create table cart
(
id int primary key,
nm varchar(20),
disc varchar(20),
price int,
img varchar(30),
qty int,
)


select * from cart
alter table cart
alter column img varchar(60)
truncate table cart
