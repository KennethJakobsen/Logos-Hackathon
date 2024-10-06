## **Project Overview**

You're building a pizza restaurant application with a microservices architecture, using the following technologies:

- **Backend Technologies**: ASP.NET Core microservices, RabbitMQ, Rebus, Entity Framework Core, PostgreSQL, .NET Aspire.
- **Frontend Technology**: Blazor.
- **Architecture Principles**:
  - **Microservices per DDD**: Each service follows Domain-Driven Design principles.
  - **API Service**: Read-only access to the database, activated via HTTP.
  - **Worker Service**: Read and write access to the database, activated via AMQP (RabbitMQ).

---

## **General Prerequisites**

Before diving into specific tasks, ensure that all participants have the following prerequisites:

- **Development Environment**:
  - Install the latest version of **.NET SDK** (.NET 6 or later).
  - Set up **Visual Studio** or **Visual Studio Code** with necessary extensions.

---

## **Tasks Breakdown**

### **1. Gateway Service**

#### **Tasks**:

- **Implement HTTP Facade**:
  - Develop a Gateway service that routes HTTP requests to the appropriate backend services.

#### **Prerequisites**:

- Understanding of **API Gateway patterns**.
- Experience with **ASP.NET Core Middleware**.
- Familiarity with **HTTP routing and proxying**.

---

### **2. Menu Service**

#### **API Service (Read-only via HTTP)**

- **Implement Endpoints**:
  - **Get All Menu Items**: `/api/menu/items`
  
- **Data Access**:
  - Use Entity Framework Core to read data from the Menu database.

#### **Worker Service (Write via AMQP)**

- **Handle Messages**:
  - **Create New Menu Item**:
    - Listen for `CreateMenuItemCommand` messages via RabbitMQ.
    - Implement logic to insert new menu items into the database.

- **Message Contracts**:
  - Define message schemas for `CreateMenuItemCommand`.

#### **Database Setup**:

- **Design Schema**:
  - Create tables for Menu Items with fields like `Id`, `Name`, `Description`, `Price`, etc.

- **Migrations**:
  - Use EF Core migrations to create and update the database schema.

#### **Prerequisites**:

- Knowledge of **Entity Framework Core** with PostgreSQL.
- Experience with **Rebus** for message handling.
- Understanding of **RabbitMQ** and **AMQP protocols**.

---

### **3. Orders Service**

#### **API Service (Read-only via HTTP)**

- **Implement Endpoints**:
  - **Get Open Orders**: `/api/orders/open`
  - **Get All Orders**: `/api/orders`

#### **Worker Service (Read/Write via AMQP)**

- **Handle Messages**:
  - **Create New Order**:
    - Listen for `CreateOrderCommand` messages.
    - Insert new orders into the database.
  - **Update Order Status**:
    - Listen for `UpdateOrderStatusCommand` messages.
    - Update the status of existing orders.

- **Message Contracts**:
  - Define message schemas for `CreateOrderCommand` and `UpdateOrderStatusCommand`.

#### **Database Setup**:

- **Design Schema**:
  - Create tables for Orders with fields like `OrderId`, `CustomerName`, `Items`, `Status`, etc.

- **Migrations**:
  - Apply EF Core migrations.

#### **Prerequisites**:

- Understanding of order management systems.
- Experience with **event-driven architecture**.

---

### **4. Production Service**

#### **API Service (Read-only via HTTP)**

- **Implement Endpoints** (if needed for read operations):
  - **Get Production Status**: `/api/production/status`

#### **Worker Service (Write via AMQP)**

- **Handle Messages**:
  - **Create New Production Entry**:
    - Listen for `CreateProductionCommand` messages.
    - Insert new production tasks into the database.
  - **Change Status**:
    - Listen for `UpdateProductionStatusCommand` messages.
    - Update production statuses.

- **Message Contracts**:
  - Define message schemas for `CreateProductionCommand` and `UpdateProductionStatusCommand`.

#### **Database Setup**:

- **Design Schema**:
  - Create tables for Production with fields like `ProductionId`, `OrderId`, `Status`, `StartTime`, etc.

#### **Prerequisites**:

- Familiarity with production workflow processes.
- Experience with **event-driven systems**.

---

### **5. Notifications Service**

#### **Worker Service (Activated via AMQP)**

- **Handle Messages**:
  - **Receive Updates on IDs**:
    - Listen for various update messages (e.g., order status changes, production updates).
    - Process and possibly store or forward these notifications.

- **Implement Notification Mechanism**:
  - Decide on how notifications will be delivered (e.g., SignalR for real-time updates, email, etc.).

#### **Prerequisites**:

- Knowledge of **pub/sub messaging patterns**.
- Experience with **SignalR** (if real-time notifications are implemented).
- Understanding of **message routing** and **event aggregation**.

---

### **6. Frontend (Blazor App)**

#### **Tasks**:

- **UI Development**:
  - **Menu Page**:
    - Display all menu items.
  - **Order Page**:
    - Allow users to create new orders.
    - Display open orders and order statuses.
  - **Production Dashboard**:
    - Show production statuses and updates.

- **Integration with Gateway**:
  - Consume APIs exposed by the Gateway service.
  - Handle both read and write operations via appropriate channels.

- **State Management**:
  - Manage application state using Blazor's built-in mechanisms.

#### **Prerequisites**:

- Proficiency in **Blazor** and **Razor components**.
- Experience with **HTTP client** in Blazor for API calls.
- Understanding of **asynchronous programming** in C#.

---

### **7. Device Service**

#### **API Service (If devices communicate via HTTP)**

- **Implement Endpoints**:
  - **Respond to Orders**: `/api/device/respond`
    - Accept "Yes" or "No" responses to orders.

#### **Worker Service (If devices communicate via AMQP)**

- **Handle Messages**:
  - **Process Device Responses**:
    - Listen for `DeviceResponse` messages.
    - Update orders or production statuses based on device input.

#### **Prerequisites**:

- Experience with **IoT devices** or external systems integration.
- Understanding of **real-time communication protocols**.

---

## **Additional Considerations**

- **Message Routing and Handling**:
  - Ensure that messages are correctly routed between services.

- **Error Handling and Logging**:
  - Implement robust error handling mechanisms.
  - Use logging frameworks (e.g., Serilog) to log information for diagnostics.

- **Scalability**:
  - Design services to be stateless where possible to allow horizontal scaling.

- **Testing**:
  - Write unit and integration tests for critical components.
  - Mock external dependencies where necessary.

---

## **Final Notes**

- **Team Coordination**:
  - Assign tasks based on team members' strengths and expertise.
  - Use version control systems like **Git** for collaborative development.

- **Time Management**:
  - Prioritize core functionalities that deliver the most value.
  - Be mindful of the hackathon time constraints.

- **Documentation**:
  - Maintain clear documentation of APIs and message contracts.
  - Comment code where necessary for clarity.

