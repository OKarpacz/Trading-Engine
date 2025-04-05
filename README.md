# Trading Engine

**Trading Engine** is a high-performance, modular system for processing financial orders, implemented in C#. It supports core order handling features, distinguishing between buy/sell sides, and manages order price and quantity, providing a solid foundation for further expansion into a full-fledged matching engine.

---

## Key Features

- Core order lifecycle management
- Distinction between buy and sell orders
- Accurate tracking of order price and quantities
- Support for increasing or decreasing order quantity
- Clean, extensible, object-oriented design
- Ready for extension with matching logic or order book functionality

---

## Project Structure

```
Trading-Engine/
├── OrdersCS/
│   ├── Order.cs          # Main order object
│   ├── IOrderCore.cs     # Interface for order metadata
│   └── ModifyOrder.cs    # DTO for modifying orders
├── README.md             # You're here!
└── ...
```

---

## System Requirements

- .NET SDK 7.0 or higher
- Visual Studio, JetBrains Rider, or Visual Studio Code

---

## Getting Started

1. **Clone the repository:**

```bash
git clone https://github.com/OKarpacz/Trading-Engine.git
cd Trading-Engine
```

2. **Build the project:**

```bash
dotnet build
```

3. *(Optional)* Extend or test the engine by implementing additional logic, such as a matching algorithm.

---

## Roadmap

- [ ] Implement a complete order matching engine
- [ ] Add comprehensive unit and integration tests
- [ ] Support additional order types (e.g., limit, market)
- [ ] Improve logging and error handling capabilities
- [ ] Code an Orderbook

---

## Contributing

Contributions are welcome. To contribute:

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Open a pull request

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Author

Developed by **OKarpacz**
