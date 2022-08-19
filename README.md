Commutators


/// SQL Task: https://dbfiddle.uk/?rdbms=sqlserver_2019&fiddle=f6a60c67e4555a07a65096c06eeaf785

select top 10 r.RegionName, prod.ProductName, oi.ProductCount, sum(p.Id) as Cnt, oi.ProductCount * pr.Price as TotalSum 
from OrderItem oi
join Person p on p.Id = oi.PersonId
join Price pr on pr.Id = oi.PriceId
join Region r on r.Id = p.RegionId
join Product prod on prod.Id = pr.ProductId
group by r.RegionName, prod.ProductName, oi.ProductCount, pr.Price
having oi.ProductCount > 2 and oi.ProductCount * pr.Price > 10000 and sum(p.Id) > 1
order by r.RegionName asc
