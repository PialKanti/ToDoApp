import { createApp } from 'vue'
import App from './App.vue'


/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

/* import specific icons */
import { faLocationDot, faCheckCircle as faCheckCircleSolid } from '@fortawesome/free-solid-svg-icons'
import {
    faCalendarDays, faCheckCircle as faCheckCircleRegular,
    faPenToSquare, faTrashCan, faPlusSquare, faClock, faCaretSquareDown, faCaretSquareRight
} from '@fortawesome/free-regular-svg-icons'

/* add icons to the library */
library.add(faLocationDot, faCalendarDays, faCheckCircleRegular, faCheckCircleSolid,
    faPenToSquare, faTrashCan, faPlusSquare, faClock, faCaretSquareDown, faCaretSquareRight)

createApp(App)
    .component('font-awesome-icon', FontAwesomeIcon)
    .mount('#app')
