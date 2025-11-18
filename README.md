# Hotel System with C#
![Status](https://img.shields.io/badge/status-active-brightgreen)
![Version](https://img.shields.io/badge/version-0.1-blue)
![Language](https://img.shields.io/badge/language-C%23-178600)
![License](https://img.shields.io/badge/license-none-lightgrey)

A console-based hotel management system built entirely in C#.  
It registers guests, manages suites, creates reservations, calculates total stay costs, and organizes hotel operations using clean object-oriented structure.

---

## 🌐 Language Index
- <img src="https://twemoji.maxcdn.com/2/svg/1f1fa-1f1f8.svg" width="20" /> **English Version** → (you are here)
- <img src="https://twemoji.maxcdn.com/2/svg/1f1e7-1f1f7.svg" width="20" /> [**Versão Em Português**](#sistema-de-hotel-em-c)

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
```
### Contributing

Fork the repository

Create a new branch

Add your improvements

Open a pull request

---

# Sistema de Hotel em C#
![Status](https://img.shields.io/badge/status-ativo-brightgreen)
![Versão](https://img.shields.io/badge/versão-0.1-blue)
![Linguagem](https://img.shields.io/badge/linguagem-C%23-178600)
![Licença](https://img.shields.io/badge/licença-nenhuma-lightgrey)

## 🌐 Índice de Idiomas
- <img src="https://twemoji.maxcdn.com/2/svg/1f1fa-1f1f8.svg" width="20" /> [**English Version**](#hotel-system-with-c)
- <img src="https://twemoji.maxcdn.com/2/svg/1f1e7-1f1f7.svg" width="20" /> **Versão em Português** → (você está aqui)

Um sistema de gerenciamento de hotel feito inteiramente em C#.  
Ele registra hóspedes, gerencia suítes, cria reservas, calcula o valor total da estadia e organiza as operações do hotel usando uma estrutura de orientação a objetos simples e bem definida.

---

## 📚 Índice
- [Descrição](#descrição)
- [Funcionalidades](#funcionalidades)
- [Arquitetura/Design](#arquiteturadesign)
- [Motivação / Por que este projeto?](#motivação--por-que-este-projeto)
- [Instalação](#instalação)
  - [Requisitos](#requisitos)
  - [Rodando o projeto](#rodando-o-projeto)
- [Contribuição](#contribuição)

---

## Descrição

O **Hotel System** é um aplicativo de console desenvolvido em C# para simular as operações essenciais de um hotel real.  
Ele gerencia o cadastro de hóspedes, registro de suítes, criação de reservas, cálculo da estadia e fornece um fluxo totalmente interativo pelo terminal.

Este projeto foi criado como exercício para fortalecer fundamentos de C#, lógica backend e conceitos de programação orientada a objetos.

---

## Funcionalidades

- Registrar novos hóspedes  
- Registrar suítes disponíveis no hotel  
- Criar reservas vinculando hóspedes e suítes  
- Calcular o valor total da estadia com base nos dias reservados  
- Exibir resumos das reservas  
- Listar todos os hóspedes cadastrados  
- Listar todas as suítes cadastradas  
- Sistema completamente interativo via console  
- Arquitetura limpa baseada em OOP  

---

## Arquitetura/Design

### **Guest.cs**
Armazena informações do hóspede, como nome e documento.

### **Suite.cs**
Define os atributos da suíte, incluindo descrição, capacidade e valor da diária.

### **Reservation.cs**
Vincula um hóspede a uma suíte, controla a quantidade de dias reservados e executa o cálculo do valor total.

### **Hotel.cs**
Gerencia listas globais de hóspedes e suítes, além de oferecer operações de alto nível.

### **Program.cs**
Ponto de entrada da aplicação.  
Gerencia menus, entrada de dados e chama a lógica das demais classes.

---

### Fluxo Geral

Program.cs (Menu & Entrada)
↓
Hotel.cs (operações principais)
↓
Guest.cs / Suite.cs / Reservation.cs (dados & regras)


---

## Motivação / Por que este projeto?

- Praticar conceitos de orientação a objetos com um caso realista  
- Construir uma aplicação de console completa do zero  
- Modelar entidades e relações (hóspedes, suítes, reservas)  
- Fortalecer fundamentos de C# usando uma arquitetura clara e organizada  

---

## Instalação

### Requisitos
- Windows, Linux ou macOS  
- .NET SDK instalado  
- Nenhuma dependência externa  

---

### Rodando o projeto

```bash
git clone https://github.com/MikaelTeixeira/Hotel-System
cd Hotel-System
dotnet run
```

### Contribuição

Faça um fork do repositório

Crie uma nova branch

Adicione suas melhorias

Abra um pull request
