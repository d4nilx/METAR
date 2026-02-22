# ✈️ METAR — Aviation Weather Decoder

A clean, modern .NET MAUI application that fetches and decodes real-time aviation weather reports (METAR) for any airport in the world using its ICAO code.

## 🚀 Features

- Search any airport by its 4-letter ICAO code (e.g. `EPWA`, `EGLL`, `KJFK`)
- Displays decoded weather including:
  - 💨 Wind speed and direction
  - 👁️ Visibility (miles and meters)
  - 🌡️ Temperature (°C and °F)
  - ⬇️ Pressure (mb and inHg)
  - ☁️ Cloud layers and height
  - 💧 Humidity
  - 🕒 Observation time
- Color-coded **Flight Category** badge:
  - 🟢 **VFR** — Visual Flight Rules (great conditions)
  - 🔵 **MVFR** — Marginal VFR (acceptable)
  - 🔴 **IFR** — Instrument Flight Rules (poor visibility)
  - 🟣 **LIFR** — Low IFR (very poor, dangerous)
- Raw METAR string displayed for reference
- Error handling for invalid codes or network issues

---

## 🛠️ Tech Stack & Architecture

This project follows clean architecture principles and modern C# practices.

| Layer | Technology |
|---|---|
| Framework | .NET 10 / MAUI |
| Language | C# |
| Architecture | MVVM (Model-View-ViewModel) |
| MVVM Helpers | CommunityToolkit.Mvvm (`[ObservableProperty]`, `[RelayCommand]`) |
| JSON | System.Text.Json (built-in, fast deserialization) |
| Weather Data | [CheckWX API](https://www.checkwx.com/) |
| IDE | JetBrains Rider |
| Target Platforms | iOS, Android, macOS (Catalyst) |

---

## 📁 Project Structure

```
METAR/
├── Models/
│   └── MetarModel.cs         # Data classes that map the API JSON response
├── Services/
│   └── WeatherService.cs     # Handles async HTTP requests to the CheckWX API
├── ViewModels/
│   └── MainViewModel.cs      # State management, commands, and data formatting
├── Views/
│   ├── MainPage.xaml         # XAML UI layout
│   └── MainPage.xaml.cs      # Code-behind (connects View to ViewModel)
├── App.xaml.cs               # App entry point
└── MauiProgram.cs            # App builder and font/service configuration
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or JetBrains Rider with the MAUI workload installed
- A free API key from [CheckWX](https://www.checkwx.com/)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/d4nilx/METAR.git
   cd METAR
   ```

2. Open the solution file:
   ```
   METAR.sln
   ```

3. Add your API key in `Services/WeatherService.cs`:
   ```csharp
   private const string ApiKey = "YOUR_API_KEY_HERE";
   ```

4. Select your target platform (iOS Simulator, Android Emulator, etc.) and run.

---

## 💡 Usage

1. Launch the app
2. Type an ICAO airport code into the search box (e.g. `EPPO` for Poznań)
3. Press **Search** or hit Enter
4. View the decoded weather report

---

## ⚠️ Known Issues / Limitations

- The CheckWX API may return numeric values for visibility fields at some airports (e.g. EPPO). This is handled by typing those fields as `double` instead of `string` in `MetarModel.cs`.
- The API key is currently hardcoded. For production use, consider storing it securely using .NET MAUI's `SecureStorage`.
- No offline support — requires an active internet connection.

---

## 📄 License

This project is for educational and personal use. Weather data is provided by [CheckWX](https://www.checkwx.com/) under their API terms of service.

*Created by Daniil Zhdanov*
