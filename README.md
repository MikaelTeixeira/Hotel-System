# Hotel System with C#
![Status](https://img.shields.io/badge/status-active-brightgreen)
![Version](https://img.shields.io/badge/version-0.1-blue)
![Language](https://img.shields.io/badge/language-C%23-178600)
![License](https://img.shields.io/badge/license-none-lightgrey)

A console-based hotel management system built entirely in C#.  
It registers guests, manages suites, creates reservations, calculates total stay costs, and organizes hotel operations using clean object-oriented structure.

---

## 📚 Index
- [Description](#description)
- [Features](#features)
- [Architecture/Design](#architecturedesign)
- [Motivation / Why This Project?](#motivation--why-this-project)
- [Installation](#installation)
  - [Requirements](#requirements)
  - [Running the project](#running-the-project)
- [Contributing](#contributing)

---

## Description

The **Hotel System** is a C# console application designed to simulate key operations of a real hotel.  
It manages guest registration, suite records, reservation creation, stay calculation, and displays summaries in a fully interactive terminal interface.

This project was created as an exercise to strengthen C#, object-oriented programming, and general backend logic.

---

## Features
- Register new guests  
- Register hotel suites  
- Create reservations linking guests and suites  
- Calculate total stay cost based on number of days and suite daily rate  
- Display reservation summaries  
- List all guests  
- List all suites  
- Fully interactive console system  
- Clean object-oriented design  

---

## Architecture/Design

### **Guest.cs**
Stores guest information such as name and document data.

### **Suite.cs**
Contains suite attributes such as description, capacity, and daily rate.

### **Reservation.cs**
Links a guest to a suite, manages days reserved, and calculates total cost.

### **Hotel.cs**
Manages global lists (available suites, registered guests) and provides high-level operations.

### **Program.cs**
Entry point of the application.  
Handles menus, input, and calls main logic from other classes.

---

### **Flow Overview**

Program.cs (Menu & Input)
↓
Hotel.cs (high-level operations)
↓
Guest.cs / Suite.cs / Reservation.cs (data & rules)


---

## Motivation / Why This Project?

- Practice object-oriented concepts with a real scenario  
- Create a structured console application from scratch  
- Understand logical modeling involving guests, suites and reservations  
- Strengthen C# fundamentals in a clean, organized architecture  

---

## Installation

### Requirements
- Windows, Linux or macOS  
- .NET SDK installed  
- No external packages required  

---

### Running the project

```bash
git clone https://github.com/MikaelTeixeira/Hotel-System
cd Hotel-System
dotnet run

