-- Create ORDER TABLE
CREATE TABLE OrderTable (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    Itemname nvarchar(200),
    Time DATETIME,
    TotalAmount MONEY,
    FOREIGN KEY (UserID) REFERENCES UserTable12(UserID)
);
drop table OrderTable
-- Create MENU ITEM TABLE
CREATE TABLE MenuItemTable (
    Item_ID INT PRIMARY KEY IDENTITY(1,1),
    Item_Name VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2),
    Description VARCHAR(MAX)
);
select * from OrderTable
-- Inserting cafe items data into the Items table

drop table MenuItemTable

	drop table Items

	INSERT INTO MenuItemTable (Item_Name, Category, Price, Description)
VALUES
    ('Espresso', 'Coffees', 2.99, 'Strong black coffee brewed by forcing hot water through finely-ground coffee beans.'),
    ('Cappuccino', 'Coffees', 3.99, 'Coffee made with espresso and steamed milk foam.'),
    ('Latte', 'Coffees', 4.49, 'Coffee with espresso and steamed milk.'),
    ('Mocha', 'Coffees', 4.99, 'Coffee mixed with chocolate syrup and steamed milk.'),
    ('Croissant', 'Breakfast Items', 2.49, 'Buttery, flaky, and crescent-shaped pastry.'),
    ('Blueberry Muffin', 'Breakfast Items', 2.99, 'Muffin made with blueberries and a crumbly top.'),
    ('Bagel with Cream Cheese', 'Breakfast Items', 3.49, 'Plain bagel served with cream cheese.'),
    ('Cheesecake', 'Desserts', 4.99, 'Rich and creamy dessert with a graham cracker crust.'),
    ('Caesar Salad', 'Salads', 5.99, 'Salad made with romaine lettuce, croutons, Parmesan cheese, and Caesar dressing.'),
    ('Chicken Sandwich', 'Brunch Menu', 7.99, 'Grilled chicken sandwich with lettuce, tomato, and mayonnaise.'),
    ('Spaghetti Carbonara', 'Signature Dishes', 9.99, 'Pasta dish with bacon, eggs, and Parmesan cheese in a creamy sauce.'),
    ('Nachos', 'Snacks', 6.49, 'Tortilla chips topped with cheese, salsa, and jalapeños.'),
    ('Smoothie Bowl', 'Breakfast Items', 6.99, 'Blended fruit smoothie served in a bowl with various toppings.'),
    ('Eggs Florentine', 'Brunch Menu', 8.49, 'Poached eggs with spinach on an English muffin topped with hollandaise sauce.'),
    ('Tiramisu', 'Desserts', 5.49, 'Italian coffee-flavored dessert made with ladyfingers and mascarpone cheese.'),
    ('Hummus Platter', 'Snacks', 5.99, 'Chickpea-based dip served with pita bread and vegetables.'),
    ('Iced Tea', 'Beverages', 2.49, 'Chilled tea served with ice cubes.'),
    ('Veggie Wrap', 'Sandwiches', 6.99, 'Wrap filled with assorted vegetables and sauce.'),
    ('Fruit Smoothie', 'Beverages', 4.99, 'Blended drink made with assorted fruits.'),
    ('Baguette', 'Breads', 3.49, 'French-style bread loaf.'),
    ('Fruit Parfait', 'Desserts', 3.99, 'Layered dessert with yogurt, granola, and fresh fruits.'),
    ('Greek Gyro', 'Sandwiches', 8.49, 'Mediterranean sandwich with meat, veggies, and tzatziki sauce.'),
    ('Tuna Salad', 'Salads', 6.49, 'Salad made with tuna, lettuce, tomatoes, and dressing.'),
    ('Veggie Omelette', 'Breakfast Items', 5.99, 'Omelette filled with assorted vegetables.'),
    ('Grilled Cheese Sandwich', 'Sandwiches', 4.99, 'Classic sandwich with melted cheese.'),
    ('Frappe', 'Beverages', 3.99, 'Greek iced coffee drink with foam.'),
    ('Chicken Caesar Wrap', 'Sandwiches', 7.49, 'Wrap with grilled chicken, lettuce, Parmesan, and Caesar dressing.'),
    ('Quinoa Salad', 'Salads', 7.99, 'Salad made with quinoa, mixed greens, and vinaigrette.'),
    ('Pesto Pasta', 'Pasta Dishes', 9.49, 'Pasta with basil pesto sauce.'),
    ('Veggie Burger', 'Burgers', 8.99, 'Burger patty made from vegetables and served with toppings.'),
    ('Caprese Salad', 'Salads', 6.99, 'Fresh salad with tomatoes, mozzarella, and basil drizzled with balsamic glaze.'),
    ('Shrimp Tacos', 'Mexican', 10.99, 'Tacos filled with grilled shrimp, cabbage slaw, and chipotle mayo.'),
    ('Chicken Noodle Soup', 'Soups', 4.99, 'Homemade soup with chicken, noodles, and vegetables.'),
    ('Avocado Toast', 'Breakfast Items', 5.99, 'Toasted bread topped with mashed avocado, cherry tomatoes, and poached egg.'),
    ('Sushi Platter', 'Japanese', 14.99, 'Assorted sushi rolls with soy sauce and wasabi.'),
    ('Pumpkin Spice Latte', 'Seasonal Beverages', 4.99, 'Espresso with steamed milk, pumpkin spice flavor, and whipped cream.'),
    ('Caprese Panini', 'Sandwiches', 8.49, 'Panini with fresh mozzarella, tomatoes, basil, and balsamic glaze.'),
    ('Chocolate Chip Cookies', 'Desserts', 2.99, 'Homemade chocolate chip cookies served warm.'),
    ('Vegetarian Burrito', 'Mexican', 9.49, 'Burrito filled with rice, beans, cheese, and assorted veggies.'),
    ('Falafel Wrap', 'Middle Eastern', 7.99, 'Wrap with crispy falafel, lettuce, tomatoes, and tahini sauce.'),
    ('Pineapple Upside-Down Cake', 'Desserts', 5.99, 'Classic dessert with caramelized pineapple and a buttery cake base.');

    select distinct Category from MenuItemTable
    drop table OrderItemTable
    select * from MenuItemTable
-- Create ORDER ITEM TABLE
CREATE TABLE OrderItemTable (

    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    Item_ID INT,
    ItemName nvarchar(200),
    Quantity INT,
    Price MONEY,
    FOREIGN KEY (OrderID) REFERENCES OrderTable(OrderID),
    FOREIGN KEY (Item_ID) REFERENCES MenuItemTable(Item_ID)
);
select * from OrderItemTable
-- Create INVENTORY ITEM TABLE
CREATE TABLE InventoryItemTable (
    ItemID INT PRIMARY KEY IDENTITY (1,1),
    Name NVARCHAR(255),
    Quantity INT,
    Threshold INT,
    FOREIGN KEY (ItemID) REFERENCES MenuItemTable(Item_ID)
);
DROP TABLE InventoryItemTable
select * from InventoryItemTable
select * from InventoryItemTable
INSERT INTO InventoryItemTable ( Name, Quantity, Threshold)
VALUES
    ( 'Fruit Parfait', 25, 7),
    ( 'Greek Gyro', 20, 6),
    ( 'Tuna Salad', 15, 4),
    ( 'Veggie Omelette', 40, 12),
    ( 'Grilled Cheese Sandwich', 35, 10),
    ( 'Frappe', 28, 9),
    ( 'Chicken Caesar Wrap', 22, 6),
    ( 'Quinoa Salad', 18, 5),
    ( 'Pesto Pasta', 35, 10),
    ( 'Veggie Burger', 28, 9),
    ( 'Caprese Salad', 22, 6),
    ('Shrimp Tacos', 15, 4),
    ( 'Chicken Noodle Soup', 30, 8),
    ( 'Avocado Toast', 25, 6),
    ( 'Sushi Platter', 20, 7),
    ( 'Pumpkin Spice Latte', 35, 10),
    ( 'Caprese Panini', 28, 9),
    ( 'Chocolate Chip Cookies', 22, 6),
    ( 'Vegetarian Burrito', 18, 5),
    ( 'Falafel Wrap', 35, 10),
    ( 'Pineapple Upside-Down Cake', 28, 9),
    ( 'Avocado Roll', 22, 6),
    ( 'Vegetable Soup', 15, 4),
    ( 'Chicken Teriyaki Bowl', 30, 8),
    ('Caesar Wrap', 25, 6),
    ( 'Spinach Artichoke Dip', 20, 7),
    ( 'Apple', 30, 10),
    ( 'Cheese', 25, 8),
    ( 'Pickle', 22, 6),
    ( 'Ketchup', 18, 5),
    ( 'Avocado Roll', 22, 6),
    ( 'Vegetable Soup', 15, 4),
    ('Chicken Teriyaki Bowl', 30, 8),
    ( 'Caesar Wrap', 25, 6),
    ( 'Spinach Artichoke Dip', 20, 7),
    ( 'Apple', 30, 10),
    ( 'Cheese', 25, 8),
    ( 'Pickle', 22, 6),
    ( 'Ketchup', 18, 5),
    ( 'Avocado Roll', 22, 6),
    ( 'Vegetable Soup', 15, 4);
    Select * from InventoryItemTable
   select* from  MenuItemTable
CREATE TABLE  ViewCart (
OrderID INT, UserID INT, ItemName NVARCHAR(200), Price MONEY, TotalAmount MONEY, Quantity INT);
select * from ViewCart
-- Create SUPPLIER TABLE
CREATE TABLE SupplierTable (
    SupplierID INT PRIMARY KEY identity(1,1),
    Name NVARCHAR(255),
    ContactInfo NVARCHAR(255)
);
drop  table SupplierTable
INSERT INTO SupplierTable ( Name, ContactInfo) VALUES ('Coffee Beans Supplier', '123-456-7890'),
 ('Bakery Goods Supplier', '987-654-3210'),
( 'Dairy Products Supplier', '555-123-4567'),
( 'Fresh Produce Supplier', '777-888-9999'),
( 'Equipment and Utensils Supplier', '111-222-3333'),
( 'Soft Drinks Supplier', '444-555-6666'),
( 'Paper Goods Supplier', '888-999-0000'),
( 'Chocolate Supplier', '222-333-4444'),
( 'Cleaning Supplies Supplier', '666-777-8888'),
( 'Tea Leaves Supplier', '333-444-5555');
-- Create SUPPLY ORDER TABLE
CREATE TABLE SupplyOrderTable (
   
    SupplierID INT,
    ItemID INT,
    Quantity INT,
    Date DATETIME,
  Order_ID INT  Primary KEY IDENTITY(1,1) ,
    FOREIGN KEY (SupplierID) REFERENCES SupplierTable(SupplierID),
    FOREIGN KEY (ItemID) REFERENCES InventoryItemTable(ItemID),
     
);
drop table LoyaltyTable


CREATE TABLE LoyaltyTable (
    UserID INT PRIMARY KEY,
   Visits int,
   Username nvarchar(50),
    FOREIGN KEY (UserID) REFERENCES UserTable12(UserID)
    
);
drop table LoyaltyTable
create table customer_visits(
UserID int primary key,
Visits INT,
FOREIGN KEY (UserID) REFERENCES UserTable12(UserID));
drop table customer_visits
delete from customer_visits




drop trigger UpdateLoyaltyOnVisitThreshold

disable TRIGGER UpdateLoyaltyOnVisitThreshold ON customer_visits;
SELECT DATABASEPROPERTYEX(DB_NAME(), 'IsTriggersNotEnabled')