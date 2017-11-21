import Home from '../components/home';
import Content from '../components/content';
import Register from '../components/register';

export const routes = [
    {
        id: 1,
        path: "/content",
        component: Content
    }, {
        id: 2,
        path: "/",
        component: Home
    }, {
        id: 3,
        path: "/regsiter",
        component: Register
    }

];
