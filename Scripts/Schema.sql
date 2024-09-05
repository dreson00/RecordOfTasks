﻿-- Do budoucna těžko udržitelné schéma tabulek. 
-- Nebylo by rozumnější rozdělit na víc tabulek pro zadavatele, řešitele a další nezávislé subjekty a použít cizí klíče?


CREATE TABLE IF NOT EXISTS Tasks (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Company TEXT NOT NULL,
    Description TEXT NOT NULL,
    Creator TEXT NOT NULL,
    Assignee TEXT NOT NULL,
    ReportedDate DATE NOT NULL,
    DueDate DATE,
    Priority TEXT NOT NULL,
    Status TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS ChecklistItems (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TaskId INTEGER NOT NULL,
    Description TEXT NOT NULL,
    IsCompleted BOOLEAN NOT NULL,
    DueDate DATE,
    FOREIGN KEY (TaskId) REFERENCES Tasks(Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Messages (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TaskId INTEGER NOT NULL,
    NameUser TEXT NOT NULL,
    MessageText TEXT NOT NULL,
    Timestamp DATE NOT NULL,
    FOREIGN KEY (TaskId) REFERENCES Tasks(Id) ON DELETE CASCADE
);
