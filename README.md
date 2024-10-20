
# BloodManagement API

## Description
**BloodManagement** is an API-driven web application designed to manage blood donor information and perform CRUD (Create, Read, Update, Delete) operations. The application interacts directly with API endpoints on the frontend, ensuring smooth and efficient data management for blood donation systems.

## Features
- Manage blood donor information.
- Perform CRUD operations on donor data.
- Calculate donor eligibility based on the last donation date.
- API-driven architecture for seamless interaction between frontend and backend.

## Technologies Used
- **Backend**: C# (ASP.NET)
- **Frontend**: HTML, CSS, jQuery, AJAX
- **Database**: MSSQL
- **Tools**: Visual Studio, SQL Server Management Studio

### District Endpoints
| Method | Endpoint                                    | Description                                 |
|--------|---------------------------------------------|---------------------------------------------|
| GET    | /api/District/GetAllDistricts                | Retrieve all Bloodgroups                   |

## Blood Group Endpoints
| Method | Endpoint                                    | Description                                 |
|--------|---------------------------------------------|---------------------------------------------|
| GET    | /api/Blood/GetAllBloodgroups                | Retrieve all Districts                      |

### Donation Endpoints
| Method | Endpoint                                    | Description                                 |
|--------|---------------------------------------------|---------------------------------------------|
| GET    | /api/Donation/test                          | Test the Donation API                       |
| POST   | /api/Donation/CreateDonation                | Create a new donation                       |
| GET    | /api/Donation/GetAllDonations               | Retrieve all donations                      |
| GET    | /api/Donation/GetDonationById/{id}          | Retrieve donation by ID                     |
| GET    | /api/Donation/GetDonationByDonorID/{id}     | Retrieve donation by Donor ID               |
| GET    | /api/Donation/GetDonationByReceiverName/{name} | Retrieve donation by receiver name          |
| DELETE | /api/Donation/DeleteDonation/{id}           | Delete a donation by ID                     |
| PUT    | /api/Donation/UpdateDonation/{id}           | Update a donation by ID                     |

### Donor Endpoints
| Method | Endpoint                                    | Description                                 |
|--------|---------------------------------------------|---------------------------------------------|
| GET    | /api/Donor/test                             | Test the Donor API                          |
| GET    | /api/Donor/GetAllDonors                     | Retrieve all donors                         |
| POST   | /api/Donor/CreateDonor                      | Create a new donor                          |
| GET    | /api/Donor/GetDonorById/{id}                | Retrieve donor by ID                        |
| GET    | /api/Donor/GetDonorByBlood/{id}             | Retrieve donor by blood group ID            |
| GET    | /api/Donor/GetDonorByName/{name}            | Retrieve donor by name                      |
| DELETE | /api/Donor/DeleteDonor/{id}                 | Delete a donor by ID                        |
| PUT    | /api/Donor/UpdateDonor/{id}                 | Update donor information by ID              |

## Frontend

The frontend is built using:
- **HTML/CSS**: For structure and styling.
- **jQuery** and **AJAX**: To interact with the API asynchronously.

The main CRUD operations are managed through AJAX calls to the API.

