delete from OrderTable
select * from UserTable12
delete from customer_visits
select * from LoyaltyTable
drop table LoyaltyTable
drop table customer_visits
drop table OrderTable
drop table OrderItemTable
select * from UserTable12
select * from ViewCart
select* from OrderItemTable
delete from OrderItemTable
SELECT OT.OrderID, OT.UserID, OT.Itemname, OT.TotalAmount, OIT.ItemName AS Item, OIT.Quantity, OIT.Price 
               FROM OrderTable OT  
               JOIN OrderItemTable OIT ON OT.OrderID = OIT.OrderID 
               WHERE OT.OrderID = @OrderID AND OT.UserID = UserID
INSERT INTO ViewCart (ItemName, Order_ID, UserID, Price, TotalAmount, Quantity)
SELECT
    OIT.ItemName,
    OT.OrderID,
    OT.UserID,
    OIT.Price,
    OT.TotalAmount,
    OIT.Quantity
FROM
    OrderTable OT
JOIN
    OrderItemTable OIT ON OT.OrderID = OIT.OrderID
    select * from customer_visits 
    delete from LoyaltyTable
    select * from InventoryItemTable