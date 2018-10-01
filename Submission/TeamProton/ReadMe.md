# Contents

1. Notebooks/AIS_RawProcessing.ipynb - Expects raw AIS Zip files to be at the same level of the notebook.  Will break down zip files as specified into 15 minute CSV files.
1. Notebooks/AIS_BoundingBox.ipnyb - Takes the original 15 minute slices of data and break them into a set of files with all points bounded by a latitude and longitude into a bounding box
1. Notebooks/InteractionDetection.ipnyb - Goes through a specific boundingbox, sort by latitude and longitude, time and MMSI, resulting changes indicate potential COLREG interactions
1. Notebooks/AIS_ColFilteredCSV - Simple C# application (very hack-is) to crunch through all the AIS points in a zone for a month and produce tracks for a vessel.
1. HackTheMachine_Full.pptx - Original power point that describes our solution
