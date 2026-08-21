# SWE40006 Deployment Task 1

WiX Toolset v3 packaging of two Windows desktop applications.

## Contents
- `SampleApp/` - Task 1.1. Console app packaged into an .msi.
- `UnitConverterApp/`, `ConverterCore/` - Task 1.2 and 1.3. WinForms app
  with a class library and Newtonsoft.Json dependency.
- `UnitConverterSetup/Product.wxs` - installer authoring, six components.

## Build prerequisites
- Visual Studio 2026
- .NET Framework 4.8 targeting pack
- WiX Toolset v3.11.2 build tools (separate from the VS extension)
- .NET Framework 3.5 Windows feature enabled

Build in Release, then build the setup project to produce the .msi.
