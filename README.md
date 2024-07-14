# Appointments API

## Overview

The Appointments API is designed to manage doctor-patient appointments efficiently. It provides endpoints to 
create, retrieve, update, and delete appointments, as well as manage doctor and patient information. 
The API is structured to handle various operations related to scheduling and tracking appointments 
between doctors and patients.

## Endpoints

### Appointments

- **GET** `/api/appointments`
  - Retrieve a list of all appointments.

- **POST** `/api/appointments`
  - Create a new appointment.

- **GET** `/api/appointments/{id}`
  - Retrieve details of a specific appointment by ID.

- **DELETE** `/api/appointments/{id}`
  - Delete a specific appointment by ID.

- **GET** `/api/appointments/doctor/{doctorId}`
  - Retrieve all appointments for a specific doctor.

- **GET** `/api/appointments/doctor/{doctorId}/availability`
  - Check the availability of a specific doctor.

- **GET** `/api/appointments/patient/{patientId}`
  - Retrieve all appointments for a specific patient.

### Doctors

- **GET** `/api/doctors`
  - Retrieve a list of all doctors.

- **GET** `/api/doctors/{doctorId}`
  - Retrieve details of a specific doctor by ID.

- **PUT** `/api/doctors/{doctorId}`
  - Update details of a specific doctor by ID.

### Patients

- **GET** `/api/patients`
  - Retrieve a list of all patients.

- **GET** `/api/patients/{patientId}`
  - Retrieve details of a specific patient by ID.

- **PUT** `/api/patients/{patientId}`
  - Update details of a specific patient by ID.

### Users

- **GET** `/api/users`
  - Retrieve a list of all users.

- **POST** `/api/users`
  - Create a new user.

- **GET** `/api/users/{userId}`
  - Retrieve details of a specific user by ID.

- **PUT** `/api/users/{userId}`
  - Update details of a specific user by ID.

- **DELETE** `/api/users/{userId}`
  - Delete a specific user by ID.

## Purpose

The primary goal of the Appointments API is to streamline the process of scheduling and managing appointments 
between doctors and patients. It also aims to maintain an organized record of all involved parties, ensuring 
easy access to relevant information. This API serves as a backbone for healthcare applications that require 
efficient appointment handling and management of doctor-patient interactions.
