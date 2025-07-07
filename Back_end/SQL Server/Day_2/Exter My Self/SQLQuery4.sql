--use KxP_store;

/*select
last_name,
first_name,
points,
points * 10 + 100 as 'discont factor'
from customers
*/
--where customer_id = 1
--order by first_name 


--select distinct state
--from customers

/*select *
from orders
where order_date <=  '2018-01-01' 
*/

select * 
from customers
--where birth_date > '1990-01-01' or (points > 1000 and state = 'va')
where not (birth_date > '1990-01-01' or points > 1000 )
select*
from order_items
where order_id = 6 and unit_price * quantity > 30


