This repository includes a full-stack library management system. 


**Case:**
A local library wants to implement a website for it's clients to browse and rent books and a in-unit system for employees to manage them. 
<br>

**Requirements:**
Design and Implement a website for clients, an application for employees, and a database to contain all information. Library must meet the requirements for
  maintaining the system, which includes but it is not limited to: (electric service, internet service, computer). 
  <br>

**Website: mylibraryy.online**
At the initial phase of the website's walktrough the client will encounter a log in page in which they can choose between logging in with an existing account or signing up a new one.
<br>
![2022-10-29 (2)](https://user-images.githubusercontent.com/74178789/198829480-b199a468-5382-4bd4-948f-90e855e53441.png)
<br>
After logging in, the php file 'connection' will verify the connection to the database and redirect the client to the home page. 
<br>
![2022-10-29 (4)](https://user-images.githubusercontent.com/74178789/198829562-3020e603-222b-4909-abea-d705ffadd96c.png)
<br>
Once the clients are in the home page, they can browse books and add them to a cart.
<br>
![2022-10-29 (5)](https://user-images.githubusercontent.com/74178789/198829699-c9448812-e11a-44e9-a3c5-b4da658e05bf.png)
![2022-10-29 (6)](https://user-images.githubusercontent.com/74178789/198829704-3407cffb-c9a9-40eb-9f00-29c65bafe44d.png)
<br>
Then, the clients can either confirm the books or continue browsing. If they decide to confirm the books in cart, an order will be created in the database with a 'pending' status (on which employees must physically get the books and prepare it). While the order status is 'pending' the clients can cancel the order at anytime via 'My Orders' tab.
<br>
![2022-10-29 (8)](https://user-images.githubusercontent.com/74178789/198829928-e46c6878-92d9-4864-a982-34ad600204a0.png)
<br>
While the order is being prepared, the user must revisit 'My Orders' tab to know when the books have been dispatched (order status).
