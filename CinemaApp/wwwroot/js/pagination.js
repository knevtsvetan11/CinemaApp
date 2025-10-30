// wwwroot/js/pagination.js

document.addEventListener('DOMContentLoaded', initializePagination);

/**
 * Инициализира функционалността за пагинация ("Load More").
 * Тази функция трябва да се извика само веднъж при зареждане на страницата.
 */
function initializePagination() {
    console.log("pagination.js: Инициализиране на пагинация.");

    const cardsToShowPerClick = 4; // Колко карти да се показват при всяко кликване
    const initialCardsCount = 8;    // Колко карти са видими при зареждане на страницата

    const loadMoreBtn = document.getElementById('loadMoreBtn');
    const cinemaCards = document.querySelectorAll('.cinema-card');
    let currentVisibleCount = initialCardsCount;

    // 1. Скриване на всички карти след първоначалния брой
    cinemaCards.forEach((card, index) => {
        // Скриваме всички карти, които са след първите 'initialCardsCount'
        if (index >= initialCardsCount) {
            card.style.display = 'none';
        }
    });

    // 2. Добавяне на слушател на бутона "Load More"
    if (loadMoreBtn) {
        loadMoreBtn.addEventListener('click', loadMoreCards);

        // Скриваме бутона, ако няма повече карти за показване (т.е. ако общият брой е <= 8)
        if (cinemaCards.length <= initialCardsCount) {
            loadMoreBtn.style.display = 'none';
        }
    }

    /**
     * Показва следващата порция скрити карти.
     */
    function loadMoreCards() {
        const nextBatchEnd = currentVisibleCount + cardsToShowPerClick;
        let cardsShownInThisBatch = 0;

        for (let i = currentVisibleCount; i < nextBatchEnd && i < cinemaCards.length; i++) {
            // Показваме следващата скрита карта
            cinemaCards[i].style.display = 'block';
            cardsShownInThisBatch++;
        }

        // Актуализираме броя на вече видимите карти
        currentVisibleCount += cardsShownInThisBatch;

        // Скриваме бутона, ако всички карти вече са показани
        if (currentVisibleCount >= cinemaCards.length) {
            loadMoreBtn.style.display = 'none';
        }
    }
}

// За да може да се извика и от cinemas.js, ако е необходимо
window.initializePagination = initializePagination;