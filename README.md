
# 📦 OrderManagement API & Services Documentation

## 📘 API Overview

### GET `/api/Orders/analytics`

Retrieves analytics data for all orders in the system.

This endpoint returns useful metrics such as **average order value** and **average fulfillment time**.

#### 🔖 Tags
- `Orders`

#### ✅ Response

**200 OK**

Returns a JSON object with analytics data.

##### Content Types:
- `application/json`
- `text/json`
- `text/plain`

##### 📐 Schema: `OrderAnalyticsDto`

| Property                        | Type    | Format | Description                                  |
|--------------------------------|---------|--------|----------------------------------------------|
| `averageOrderValue`            | number  | double | The average value of all completed orders    |
| `averageFulfillmentTimeInHours`| number  | double | The average time (in hours) to fulfill orders|

##### 📦 Sample Response
```json
{
  "averageOrderValue": 125.50,
  "averageFulfillmentTimeInHours": 4.2
}
```

---

## 🛠️ `OrderService` Class

### Constructor

```csharp
public OrderService(ILoyalityService loyalityService, IDiscountService discountService)
```
Initializes a new instance of the `OrderService` class with injected dependencies.

#### Parameters:
- `ILoyalityService loyalityService`: A service that classifies customers into segments (e.g., New, Regular, Loyal, VIP) based on their order history.
- `IDiscountService discountService`: A service that calculates and applies appropriate discounts based on the customer segment.

---

### Method: `HandleOrder`

```csharp
public async Task<Order> HandleOrder(Order order)
```

Processes the given order by evaluating the customer's segment and applying a relevant discount.

#### Parameters:
- `Order order`: The order to be handled. It includes the `CustomerId` and the original `TotalAmount`.

#### Returns:
- `Order`: The updated order with the final discounted `TotalAmount`.

#### Workflow:
1. Retrieves the customer's segment using the `ILoyalityService.Calculate()` method.
2. Applies a discount using the `IDiscountService.ApplyDiscount()` method based on the customer's segment.
3. Updates the order's total amount with the discounted value.
4. Returns the updated order.

#### Example Usage:
```csharp
var order = new Order { CustomerId = 123, TotalAmount = 200.00M };
var processedOrder = await orderService.HandleOrder(order);
Console.WriteLine(processedOrder.TotalAmount); // e.g., 180.00 if discount applied
```

---

## 🛡️ Notes
- The service follows best practices in dependency injection.
- Easily testable and extensible with additional business rules.
- Helps maintain separation of concerns (loyalty logic vs. discount logic).

