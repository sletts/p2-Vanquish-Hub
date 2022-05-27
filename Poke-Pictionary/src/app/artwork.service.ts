import { Injectable, } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
// commenting the below code snipit out as I am implementing 
// the ArtworkService and will use that unless I need both
/**class CanvasPoke{

}
new CanvasPoke();**/
export class ArtworkService {
  private canvas: HTMLCanvasElement;
  private context: CanvasRenderingContext2D;
  private paint: boolean;

  private clickX: number[] = [];
  private clickY: number[] = [];
  private clickDrag: boolean[] = [];
  
  constructor() {

    
    let canvas= document.getElementById('canvas') as HTMLCanvasElement;
    let context= canvas.getContext("2d") as CanvasRenderingContext2D;
    context.lineCap= 'round';
    context.lineJoin= 'round';
    context.strokeStyle= 'black';
    context.lineWidth= 1;

    this.canvas= canvas;
    this.context= context;
    this.yourDrawing();
    this.createUserEvents();
    
   }
   private createUserEvents(){
      let canvas= this.canvas;

      canvas.addEventListener("mousedown", this.pressEventHandler);
      canvas.addEventListener("mousemove", this.dragEventHandler);
      canvas.addEventListener("mouseup", this.releaseEventHandler);
      canvas.addEventListener("mouseout", this.cancelEventHandler);
      canvas.addEventListener("touchstart", this.pressEventHandler);
      canvas.addEventListener("touchmove", this.dragEventHandler);
      canvas.addEventListener("touchend", this.releaseEventHandler);
      canvas.addEventListener("touchcancel", this.cancelEventHandler);

      document.getElementById('clear')
              .addEventListener('click', this.clearEventHandler);
    }
    private yourDrawing(){

      let clickX=this.clickX;
      let context= this.context;
      let clickDrag= this.clickDrag;
      let clickY= this.clickY;
      for(let i= 0; i< clickX.length; i++){
        context.beginPath();
        // Using if blocks to define where you are at on the canvas 
        // and if you are drawing.
        if (clickDrag[i] && i) {
            context.moveTo(clickX[i-1], clickY[i-1]);
        }
        else{ context.moveTo(clickX[i]-1, clickY[i]);}

        context.lineTo(clickX[i], clickY[i]);
        context.stroke();
      }
      // closing path so no security interjections can be added
      // (as an added measure the access modifiers are set to private as well)
      context.closePath();
    }
    private addClick(x: number, y:number, dragging: boolean){
      this.clickX.push(x);
      this.clickY.push(y);
      this.clickDrag.push(dragging);      
    }
    private clearYourPicture(){
      this.context.clearRect(0, 0, this.canvas.width, this.canvas.height);
      this.clickX= [];
      this.clickY= [];
      this.clickDrag= [];
    }
    // tidying up the remaining eventhandlers:
    private clearEventHandler= ()=> {this.clearYourPicture();}
    private cancelEventHandler= ()=> {this.paint= false;}
    private releaseEventHandler= ()=> {this.paint= false; this.yourDrawing();}
    
}