# spreadsheet

Minimal spreadsheet app

## Features

- CLI interface
- create spreadsheet file
- print spreadsheet
- explain cell

#### Feature: Explain Cell

Explain Cell is a feature that shows Cell logic in human readable form. Reading code in human readable form is comfortable and less energy consuming than interpreting code where you need to memorize what code does. 

### TODO

- CLI/GUI interface
- check if graph is directed acyclic graph and show error
- file system

## How spreadsheet calculates cells result

1. set logic into cells
2. add cells into graph
    - check if is directed acyclic graph
      - show error if not
    - sort topologically and reverse result
    - calculate cells results in order
