This repository includes a full-stack library management system. 


**Case:**
A local library wants to implement a website for it's clients to browse and rent books and a in-unit system for employees to manage them. 
<br>
<br>

**Requirements:**
Design and Implement a website for clients, an application for employees, and a database to contain all information. Library must meet the requirements for
  maintaining the system, which includes but it is not limited to: (electric service, internet service, computer). 
  <br>
  <br>

**Website: mylibraryy.online**
At the initial phase of the website's walktrough the client will encounter a log in page in which they can choose between logging in with an existing account or signing up a new one.
<br><br>
![2022-10-29 (2)](https://user-images.githubusercontent.com/74178789/198829480-b199a468-5382-4bd4-948f-90e855e53441.png)
<br>
<br>
After logging in, the php file 'connection' will verify the connection to the database and redirect the client to the home page. 
<br>
<br>
![2022-10-29 (4)](https://user-images.githubusercontent.com/74178789/198829562-3020e603-222b-4909-abea-d705ffadd96c.png)
<br>
<br>
Once the clients are in the home page, they can browse books and add them to a cart.
<br>
<br>
![2022-10-29 (5)](https://user-images.githubusercontent.com/74178789/198829699-c9448812-e11a-44e9-a3c5-b4da658e05bf.png)
![2022-10-29 (6)](https://user-images.githubusercontent.com/74178789/198829704-3407cffb-c9a9-40eb-9f00-29c65bafe44d.png)
<br>
<br>
Then, the clients can either confirm the books or continue browsing. If they decide to confirm the books in cart, an order will be created in the database with a 'pending' status (on which employees must physically get the books and prepare it). While the order status is 'pending' the clients can cancel the order at anytime via 'My Orders' tab.
<br>
<br>
![2022-10-29 (8)](https://user-images.githubusercontent.com/74178789/198829928-e46c6878-92d9-4864-a982-34ad600204a0.png)
<br>
<br>
While the order is being prepared, the user must revisit 'My Orders' tab to know when the books have been dispatched (order status).
<br><br><br><br>
**Employee Administration App:**
At the initial phase of the application the employee must log in with their information. Note: in the case that a new employee wants to log in, an administrator must add their info to the database using the application. 
<br>
<br>
![2022-10-29 (15)](https://user-images.githubusercontent.com/74178789/198831690-fe135ec0-adf1-4de2-9343-f7139f9c1c25.png)
<br>
<br>
After logging in, the menu will be displayed on which the employee can either, access the books database in order to Create, Edit, Add or Delete books, View and Complete orders, and Confirm handed-in orders when the client returns their books.
<br>
<br>
![2022-10-29 (17)](https://user-images.githubusercontent.com/74178789/198831963-c4872791-452f-4561-9bd2-9ce3cb7375b0.png)
![2022-10-29 (18)](https://user-images.githubusercontent.com/74178789/198831968-f5c29136-3a01-457a-98db-cf5ae378739d.png)
![2022-10-29 (22)](https://user-images.githubusercontent.com/74178789/198831980-5162b304-b44d-49ee-85e4-84579bd9f60a.png)
![2022-10-29 (24)](https://user-images.githubusercontent.com/74178789/198831983-50f2a937-e9e4-4476-b0ad-3dcdfcb2f5d3.png)
<br>
<br>
While in the menu, if the employee (not administrator) tries to access the client's or employee's database, a message will be prompt. 
<br><br>
![2022-10-29 (19)](https://user-images.githubusercontent.com/74178789/198832038-25be7a6b-581d-49fd-9307-34c57cb3461b.png)
<br><br>
However, if the employee is in fact an administrator, access to the Client Registry and Employee Database will be granted, where they can Create, Edit, Add or Delete Clients and Employees info respectively. 
<br><br>
![2022-10-29 (20)](https://user-images.githubusercontent.com/74178789/198832159-ea26780c-762f-4f0c-9bf5-04b8035c808d.png)
![2022-10-29 (21)](https://user-images.githubusercontent.com/74178789/198832130-3ea0565d-3528-4eb4-9c1e-2c9e81865679.png)
<br><br><br><br>
**Server Side:**
<br>
Book's Table:
<br>
![2022-10-29 (26)](https://user-images.githubusercontent.com/74178789/198832291-efd074df-057d-4672-9c1e-12b5961cc9d4.png)
<br><br>
Employee's Table:
<br>
![2022-10-29 (27)](https://user-images.githubusercontent.com/74178789/198832330-2c6c91ac-2e81-4371-b8c2-5a305c755376.png)
<br><br>
Order's Table:
<br>
![2022-10-29 (28)](https://user-images.githubusercontent.com/74178789/198832336-f6b31de2-698c-4a73-9beb-0a3a30bab33d.png)
<br><br>
User's Table:
![2022-10-29 (29)](https://user-images.githubusercontent.com/74178789/198832339-66204ad3-d35b-446b-92fa-446ba37bba68.png)






