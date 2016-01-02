select * from tab1


select a.name, sum(b.score) fscore
from tab1 a
left join tab2 b on a.id1=b.id1
group by a.name,b.id1
having sum(b.score)>540 or sum(b.score) is null

create table sale (saleid int primary key,
saledate date not null,
quantity int,
productid int,
constraint product_id_fk foreign key (productid) 
references product(productid))

create table product (productid int primary key,
product varchar(100),
cost money)


select * from product


insert into product values (1,'Lux soap',10.90)
insert into product values (2,'Fan',1256.90)
insert into product values (3,'Cups',6545.90)
insert into product values (4,'Shoes',5647.22)


select * from product


select * from sale

insert into sale values(1,'2010-07-10',10,2)

insert into sale values(2,'2011-09-22',988,1)
insert into sale values(3,'2009-12-01',76,4)
insert into sale values(4,'2014-03-19',17,2)
insert into sale values(5,'2013-11-17',09,3)

insert into sale values(6,'2013-11-17',10,3)

insert into sale values(7,'2013-06-22',10,2)
insert into sale values(8,'2013-09-14',10,1)


select * from sale

select sum(cost), monthVal
from 
(
select p.cost*s.quantity, Month(s.saledate) monthVal
from product p, sale s
where p.productid=s.productid
--order by 2
) as a
group by monthVal


select * from product
select * from sale

WITH
	cteMonthWiseReport(cost, monthVal,yrval)
AS
(
select p.cost*s.quantity, Month(s.saledate) monthVal,year(s.saledate) yrval
from product p, sale s
where p.productid=s.productid
and s.saledate between '2013-01-01' and convert(char(10),getdate(),126)
)
 select  sum(cost) TotalSale, datename(MONTH,DATEADD(month,monthVal,-1)) + '-' + cast (yrval as varchar) SoldInPeriod
 from cteMonthWiseReport
 group by monthval,yrval
 having sum(cost)>200
  
  
 


 select year('2012-03-10')