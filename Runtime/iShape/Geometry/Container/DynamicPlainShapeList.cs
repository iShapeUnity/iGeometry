using iShape.Collections;
using Unity.Collections;

namespace iShape.Geometry.Container {

    public struct DynamicPlainShapeList {
        
        public DynamicArray<IntVector> points;
        public DynamicArray<PathLayout> layouts;
        public DynamicArray<Segment> segments;
 
        public DynamicPlainShapeList(Allocator allocator) {
            this.points = new DynamicArray<IntVector>(0, allocator);
            this.layouts = new DynamicArray<PathLayout>(0, allocator);
            this.segments = new DynamicArray<Segment>(0, allocator);
        }

        public DynamicPlainShapeList(int minimumPointsCapacity, int minimumLayoutsCapacity, int minimumSegmentsCapacity, Allocator allocator) {
            this.points = new DynamicArray<IntVector>(minimumPointsCapacity, allocator);
            this.layouts = new DynamicArray<PathLayout>(minimumLayoutsCapacity, allocator);
            this.segments = new DynamicArray<Segment>(minimumSegmentsCapacity, allocator);            
        }
        
        public void Add(PlainShape shape) {
            this.segments.Add(new Segment(this.layouts.Count, shape.layouts.Length));
            this.points.Add(shape.points);
            this.layouts.Add(shape.layouts);
        }
        
        public void Add(DynamicPlainShape shape) {
            this.segments.Add(new Segment(this.layouts.Count, shape.layouts.Count));
            this.points.Add(shape.points);
            this.layouts.Add(shape.layouts);
        }

        public void Dispose() {
            this.points.Dispose();
            this.layouts.Dispose();
            this.segments.Dispose();
        }

        public PlainShapeList Convert() {
            return new PlainShapeList(this.points.Convert(), this.layouts.Convert(), this.segments.Convert());
        }
    }

}