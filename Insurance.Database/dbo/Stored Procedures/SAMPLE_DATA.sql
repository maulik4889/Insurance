CREATE PROCEDURE SAMPLE_DATA

AS
BEGIN
--Insert Data into ClaimType Table
Insert Into ClaimType Values ('Health Insurance Claims')
Insert Into ClaimType Values ('Property and Casualty Claims')
Insert Into ClaimType Values ('Life Insurance Claims')

--Insert Data into Company Table
Insert Into Company Values ('Admiral Group','Cardiff','David Street','Cardiff','CF10 2EH','United Kingdom','FALSE','12/17/2022 19:54')
Insert Into Company Values ('Direct Line Group','Churchill Court','Westmoreland Road','Bromley','BR1 1DP','United Kingdom','TRUE','12/17/2022 19:54')
Insert Into Company Values ('Aviva','St Helens','1 Undershaft','London','EC3P 3DQ','United Kingdom','FALSE','12/17/2022 19:54')
Insert Into Company Values ('Hastings Direct','Conquest House','Collington Avenue, Bexhill-on-Sea','East Sussex','TN39 3LW','United Kingdom','TRUE','12/17/2022 19:54')
Insert Into Company Values ('Markel (UK) Limited','2nd Floor, Verity House','6 Canal Wharf','Leeds','LS11 5AS','United Kingdom','TRUE','12/17/2022 19:54')


--Insert Data into Claims Table 
Insert Into Claims Values (1,'1/10/2022 19:53','1/10/2022 19:53','Nicole Godman','76000','TRUE')
Insert Into Claims Values (2,'2/9/2022 19:53','2/9/2022 19:53','Luke Hodges','77000','TRUE')
Insert Into Claims Values (3,'3/8/2022 19:53','3/8/2022 19:53','Jack RIdgway','78000','TRUE')
Insert Into Claims Values (4,'4/7/2022 19:53','4/7/2022 19:53','Ben Etherington','79000','TRUE')
Insert Into Claims Values (5,'5/6/2022 19:53','5/6/2022 19:53','Alex Dalorto','80000','TRUE')
Insert Into Claims Values (1,'6/5/2022 19:53','6/5/2022 19:53','Nicole Virlan','81000','FALSE')
Insert Into Claims Values (2,'7/4/2022 19:53','7/4/2022 19:53','Deniz Nevin','82000','FALSE')
Insert Into Claims Values (3,'8/3/2022 19:53','8/3/2022 19:53','Ben Berwick','83000','FALSE')
Insert Into Claims Values (4,'9/2/2022 19:53','9/2/2022 19:53','Fadi Jawish','84000','FALSE')
Insert Into Claims Values (5,'10/1/2022 19:53','10/1/2022 19:53','Nicole Godman','85000','FALSE')
END