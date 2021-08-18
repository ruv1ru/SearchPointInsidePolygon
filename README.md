# SearchPointInsidePolygon
C# function to determine whether a point is inside a polygon

To determine whether a point lies within a polygon is to add up the angles between the point and adjacent points on the polygon taken in order. 
If the total of all the angles is 2π or -2π, then the point is inside the polygon. 
If the total is zero, the point is outside. 
