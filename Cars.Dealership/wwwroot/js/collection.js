const dropdownList = document.querySelector('.side-bar--list');

dropdownList.addEventListener('click', (e) => {
    console.log("======")
    console.log(e.target)
    const option = e.target.closest('.side-bar--option');
    console.log(option)
    if (!option) return;
    
    const dropdown = option.querySelector('.dropdown');
    console.log(dropdown);
    dropdown.classList.toggle('active');
});