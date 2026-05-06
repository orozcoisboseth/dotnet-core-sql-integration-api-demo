# ASP.NET Core SQL Integration API (Demo)

Demo REST API built with ASP.NET Core that simulates an external
SQL-backed system consumed by NetSuite integrations.

This project focuses on **architecture, integration patterns,
and idempotent behavior**, not on production-ready logic.

---

## Purpose

This repository represents the **external system side** of a
NetSuite → API → Database integration.

It was created to demonstrate how a NetSuite integration can interact
with a REST API that:

- Receives transaction data from NetSuite
- Persists records into a SQL-based system (simulated)
- Prevents duplicate inserts (idempotency)
- Returns a stable external identifier back to NetSuite

This is **demo-only code**.
## Integration Flow
NetSuite (SuiteScript) *** see suitescript-sql-integration-demo repository
↓
ASP.NET Core REST API
↓
SQL Server (simulated)
↓
External ID returned to NetSuite

## Architecture Overview

The project is structured following a layered approach:
Controllers/

API endpoints
Services/
Business logic
Models/
Request and response contracts
Infrastructure/
In-memory storage simulating SQL persistence

This separation mirrors real-world enterprise API design.

---

## Idempotent Behavior

The API simulates idempotent inserts:

- If a request with the same reference is received multiple times
- The record is not duplicated
- The same external identifier is always returned

This reflects common ERP integration requirements.

---

## Scope

Included:
- ASP.NET Core REST API
- Controller / Service separation
- Request and response contracts
- Simulated SQL persistence
- Idempotency handling

Not included:
- Real SQL Server connections
- Stored procedures
- ERP-specific business logic
- Authentication or credentials
- Production configuration

---

## Disclaimer

This repository contains **demo code created from scratch**.

- No real database schema
- No production logic
- No proprietary or employer-owned code
- No real customer or ERP identifiers

This project exists solely to demonstrate
integration architecture and technical decision-making.
