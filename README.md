# spreadsheet

Minimal spreadsheet app

TODO:
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