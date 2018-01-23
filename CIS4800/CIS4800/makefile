CSFILES = Program.cs DrawImage.cs GraphicsMath.cs Vertex.cs Edge.cs

.PHONY: Program.cs

all: run

Graphics: Program.cs
	mcs /reference:System.Drawing.dll $(CSFILES) -out:Graphics.exe

clean:
	@rm -f Graphics.exe

run: Graphics
	@mono Graphics.exe