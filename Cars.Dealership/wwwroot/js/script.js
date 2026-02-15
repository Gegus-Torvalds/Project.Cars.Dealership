'use strict';
const body = document.querySelector('body');
const observedSection = document.querySelector('.why-us');

const changeColor = function (entries, observer){ 
    const [entry] = entries; 

    console.log(entry)

    entry.isIntersecting ? body.style.backgroundColor = '#ededed' : body.style.backgroundColor = 'black';
}


const observer = new IntersectionObserver(
    changeColor, 
    {
        threshold: 0.5, 
        root: null
    }
)

observer.observe(observedSection);



const arrowDown = document.querySelector('.faq');

arrowDown.addEventListener('click', (e)=>{
    const question = e.target.closest('[data-value]');
  if (!question) return; // klik van pitanja

  const arrow = question.querySelector('img.arrow-down');
  arrow.classList.toggle('rotate-180');
})