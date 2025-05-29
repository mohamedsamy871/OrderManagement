
# 📦 OrderManagement API & Services Documentation

## 📘 API Overview

### GET `/api/Orders/analytics`

Retrieves analytics data for all orders in the system.

This endpoint returns useful metrics such as **average order value** and **average fulfillment time**.

#### ✅ Response

**200 OK**

Returns a JSON object with analytics data.

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
