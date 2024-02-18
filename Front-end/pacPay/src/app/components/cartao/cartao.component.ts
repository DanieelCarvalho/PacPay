import { Component, ElementRef, HostListener, ViewChild } from '@angular/core';

@Component({
  selector: 'app-cartao',
  standalone: true,
  imports: [],
  templateUrl: './cartao.component.html',
  styleUrl: './cartao.component.css',
})
export class CartaoComponent {
  @ViewChild('card', { static: true }) card!: ElementRef;

  @HostListener('mousemove', ['$event'])
  cardEffect(event: MouseEvent) {
    const cardElement = this.card.nativeElement;
    const cardWidth = cardElement.offsetWidth;
    const cardHeight = cardElement.offsetHeight;
    const centerX = cardElement.offsetLeft + cardWidth / 2;
    const centerY = cardElement.offsetTop + cardHeight / 2;
    const positionX = event.clientX - centerX;
    const positionY = event.clientY - centerY;

    const rotateX = ((+1 * 25 * positionY) / (cardHeight / 2)).toFixed(2);
    const rotateY = ((-1 * 25 * positionX) / (cardWidth / 2)).toFixed(2);

    cardElement.style.transform = `perspective(500px) rotateX(${rotateX}deg) rotateY(${rotateY}deg)`;
  }

  @HostListener('mouseleave')
  cardBack() {
    const cardElement = this.card.nativeElement;
    cardElement.style.transform = `perspective(500px) rotateX(0deg) rotateY(0deg)`;
    this.cardTransition();
  }

  cardTransition() {
    const cardElement = this.card.nativeElement;
    clearInterval(cardElement.transitionId);
    cardElement.style.transition = 'transform 400ms';
    cardElement.transitionId = setTimeout(() => {
      cardElement.style.transition = '';
    }, 400);
  }

  @HostListener('mouseenter')
  cardEnter() {
    this.cardTransition();
  }
}
